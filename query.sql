
 Select * from [StudentResult5to8] 
Select * from  [StudentFormativeResult5to8]
Select * from [StudentInfo]

 Select * from [StudentResult5to8] UNION
Select *, (select StudentName from [StudentInfo] where [StudentInfo].studentid =  studentid)
 from  [StudentFormativeResult5to8]

 Select [StudentResult5to8].Computer,[StudentResult5to8].EnvHis,[StudentResult5to8].EnvironGeo,[StudentResult5to8].FirstLan,
 [StudentResult5to8].SecndLan,[StudentResult5to8].ThrdLan,
 [StudentResult5to8].Mathematics,[StudentResult5to8].PhysArt,[StudentResult5to8].Science,
 [StudentFormativeResult5to8].StudentId,[StudentFormativeResult5to8].StudentClass,[StudentFormativeResult5to8].StudentRoll,
 [StudentFormativeResult5to8].StudentSec,[StudentFormativeResult5to8].CreativeAesthe,[StudentFormativeResult5to8].EmpaCooperation,
 [StudentFormativeResult5to8].InterApplication,[StudentFormativeResult5to8].StudentUnit,
 [StudentFormativeResult5to8].Participation,[StudentFormativeResult5to8].QuestionExperiment,[StudentInfo].StudentName
 from  [StudentFormativeResult5to8]
 left join [StudentInfo] on [StudentInfo].StudentId = [StudentFormativeResult5to8].StudentId
 left join [StudentResult5to8] on [StudentResult5to8].StudentId = [StudentFormativeResult5to8].StudentId
 where [StudentFormativeResult5to8].StudentUnit  = 1 AND [StudentResult5to8].StudentUnit = 1

 ---------------------------------




