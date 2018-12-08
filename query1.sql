Select * from  [StudentInfo]
Select * from  [StudentResultFromNine]



Select SR.FirstLan,SR.FirstLanPrac,SR.FirstLanTheo,SR.Geography,SR.GeographyPrac,
SR.GeographyTheo,SR.History,SR.HistoryPrac,SR.HistoryTheo,SR.LifeScience,SR.LifeSciencePrac,
SR.LifeScienceTheo,SR.Mathematics,SR.MathematicsPrac,SR.MathematicsTheo,SR.PhysicalScience,
SR.PhysicalSciencePrac,SR.PhysicalScienceTheo,SR.SecondLan,SR.SecondLanPrac,SR.SecondLanTheo,
SR.StudentClass,SR.StudentId,SR.StudentRoll,SR.StudentSec,SR.StudentUnit, SI.StudentName from [StudentResultFromNine] SR
left join [StudentInfo] SI
on SR.StudentId = SI.StudentId WHERE SR.StudentUnit = 1 UNION
Select SR.FirstLan AS FirstLan1,SR.FirstLanPrac AS FirstLanPrac1,SR.FirstLanTheo AS FirstLanTheo1,SR.Geography AS FirstLanTheo1,
SR.GeographyPrac AS GeographyPrac1,SR.GeographyTheo AS GeographyTheo1,SR.History AS History1,SR.HistoryPrac AS HistoryPrac1,
SR.HistoryTheo AS HistoryTheo1,SR.LifeScience AS LifeScience1,SR.LifeSciencePrac AS LifeSciencePrac1,
SR.LifeScienceTheo AS LifeScienceTheo1,SR.Mathematics AS Mathematics1,SR.MathematicsPrac AS MathematicsPrac1,
SR.MathematicsTheo AS MathematicsTheo1,SR.PhysicalScience AS PhysicalScience1,
SR.PhysicalSciencePrac AS PhysicalSciencePrac1,SR.PhysicalScienceTheo AS PhysicalScienceTheo1,SR.SecondLan AS SecondLan1,
SR.SecondLanPrac AS SecondLanPrac1,SR.SecondLanTheo AS SecondLanTheo1,
SR.StudentClass,SR.StudentId,SR.StudentRoll,SR.StudentSec,SR.StudentUnit AS StudentUnit1, SI.StudentName from [StudentResultFromNine] SR
left join [StudentInfo] SI
on SR.StudentId = SI.StudentId WHERE SR.StudentUnit = 2