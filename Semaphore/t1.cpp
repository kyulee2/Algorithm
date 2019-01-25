#include <chrono>
#include <thread>
#include <queue>
#include <mutex>
#include <condition_variable>
#include <iostream>
using namespace std;

#define MAX_SIZE 3
class Semaphore
{
public:
mutex mtx;
condition_variable cv;
int cnt;

Semaphore(int n) : cnt(n) {}

void down() { // aquire
 unique_lock<mutex> lock(mtx);
 --cnt;
 if (cnt<0)
   cv.wait(lock);
}

void up() { // release
 unique_lock<mutex> lock(mtx);
 ++cnt;
 if (cnt<=0)
   cv.notify_one();
}
};


void consumer(int id, Semaphore& sem){
    sem.down();
    std::cout << "Consumer " << id  << std::endl;
    std::this_thread::sleep_for (std::chrono::seconds(1));
    sem.up();
}


int main(){
    Semaphore sem(MAX_SIZE);
    thread c[100];
    for(int i=0; i<100; i++)
         c[i] = thread(consumer, i, std::ref(sem));

    for(int i=0; i<100; i++)
        c[i].join();

    return 0;
}