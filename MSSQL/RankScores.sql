/* Write your T-SQL query statement below */
-- this works because the distinct count of scores will always represent our rank. smart.
select s.Score, count(r.Score) as Rank
 from Scores s, (select distinct Score from Scores) r
 where s.Score <= r.Score
 group by s.Id, s.Score
 order by s.Score desc;