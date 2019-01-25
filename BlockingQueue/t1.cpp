#include <thread>
#include <queue>
#include <mutex>
#include <condition_variable>
#include <iostream>
using namespace std;

#define MAX_SIZE 5
class BlockingQueue {
public:
 mutex mtx;
 condition_variable write, read;
 queue<int> q;

public:
 BlockingQueue() {}

 void add(int data) { // write
   {
     unique_lock<mutex> lock(mtx); // unique_lock for local scope
     write.wait(lock, [=](){ return q.size() != MAX_SIZE; });
     q.push(data);
    }
    read.notify_one();
  }

  int get() { // reader
    int ans;
    {
     unique_lock<mutex> lock(mtx); // unique_lock for local scope
     read.wait(lock, [=](){ return q.size() !=0; });
     ans = q.front();
     q.pop();
    }
    write.notify_one();
    return ans;
  }
};

void consumer(int id, BlockingQueue& buffer){
    for(int i = 0; i < 50; ++i){
        int value = buffer.get();
        std::cout << "Consumer " << id << " fetched " << value << std::endl;
        //std::this_thread::sleep_for(std::chrono::milliseconds(250));
    }
}

void producer(int id, BlockingQueue& buffer){
    for(int i = 0; i < 75; ++i){
        buffer.add(i);
        std::cout << "Produced " << id << " added " << i << std::endl;
        //std::this_thread::sleep_for(std::chrono::milliseconds(100));
    }
}

int main(){
    BlockingQueue buffer;

    std::thread c1(consumer, 0, std::ref(buffer));
    std::thread c2(consumer, 1, std::ref(buffer));
    std::thread c3(consumer, 2, std::ref(buffer));
    std::thread p1(producer, 0, std::ref(buffer));
    std::thread p2(producer, 1, std::ref(buffer));

    c1.join();
    c2.join();
    c3.join();
    p1.join();
    p2.join();

    return 0;
}