--select * from practice

select pers.Name, p.Name, P.PerspectiveId, e.* 
from evaluationPractice e
join Practice p on e.EvaluationPracticeId = p.Id
join ProcessPerspective pers on pers.Id = p.PerspectiveId
where e.EvaluationId = 3
and pers.Id = 2
order by pers.Name

select * from evaluation
select * from evaluationPractice where EvaluationId = 3

truncate table evaluationpractice
select * from practice

select * from ProcessPerspective