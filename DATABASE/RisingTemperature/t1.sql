#Given a Weather table, write a SQL query to find all dates' Ids with higher temperature compared to its previous (yesterday's) dates.
#
#+---------+------------------+------------------+
#| Id(INT) | RecordDate(DATE) | Temperature(INT) |
#+---------+------------------+------------------+
#|       1 |       2015-01-01 |               10 |
#|       2 |       2015-01-02 |               25 |
#|       3 |       2015-01-03 |               20 |
#|       4 |       2015-01-04 |               30 |
#+---------+------------------+------------------+
#For example, return the following Ids for the above Weather table:
#
#+----+
#| Id |
#+----+
#|  2 |
#|  4 |
#+----+

# Comment: Se two name for the same table. Compare them. Use TO_DAYS to get numerical day comparision.
# Write your MySQL query statement below
select wt1.Id from Weather wt1, Weather Wt2
where wt1.Temperature > wt2.Temperature
    and TO_DAYS(wt1.RecordDate) - TO_DAYS(wt2.RecordDate) = 1

