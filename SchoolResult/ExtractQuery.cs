using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolResult
{
    public class ExtractQuery
    {
       
        public string ExtractQueryforExtraction(int classNum,int unit, string sec )
        {
             string extractResult5to8 = string.Empty;
             if (unit == 3 || unit == 1 || unit == 2)
            {
                extractResult5to8 = @"Select [StudentResult5to8].Computer,[StudentResult5to8].EnvHis,[StudentResult5to8].EnvironGeo,[StudentResult5to8].FirstLan,
                                    [StudentResult5to8].SecndLan,[StudentResult5to8].ThrdLan,
                                    [StudentResult5to8].Mathematics,[StudentResult5to8].PhysArt,[StudentResult5to8].Science,
                                    [StudentResult5to8].StudentId,[StudentResult5to8].StudentClass,[StudentResult5to8].StudentRoll,
                                    [StudentResult5to8].StudentSec,[StudentFormativeResult5to8].CreativeAesthe,[StudentFormativeResult5to8].EmpaCooperation,
                                    [StudentFormativeResult5to8].InterApplication,[StudentFormativeResult5to8].StudentUnit,
                                    [StudentFormativeResult5to8].Participation,[StudentFormativeResult5to8].QuestionExperiment,[StudentInfo].StudentName                                    
									into #table1  from [StudentResult5to8] 
									left join [StudentInfo] on [StudentInfo].StudentId = [StudentResult5to8].StudentId
									left join [StudentFormativeResult5to8] on [StudentFormativeResult5to8].StudentId = [StudentInfo].StudentId
									where [StudentResult5to8].StudentClass = ";

                extractResult5to8 += classNum + " and [StudentFormativeResult5to8].StudentClass = " + classNum + " and [StudentResult5to8].StudentSec = '" + sec + "' and [StudentFormativeResult5to8].StudentSec = '" + sec + "' " + @"
									--and [StudentResult5to8].StudentSec = 'A' 
									 and [StudentResult5to8].StudentUnit = 1 and [StudentFormativeResult5to8].StudentUnit = 1
									--union all
									Select [StudentResult5to8].Computer AS Computer1,[StudentResult5to8].EnvHis as EnvHis1,
									[StudentResult5to8].EnvironGeo AS EnvironGeo1,[StudentResult5to8].FirstLan as FirstLan1,
                                    [StudentResult5to8].SecndLan as SecndLan1,[StudentResult5to8].ThrdLan as ThrdLan1,
                                    [StudentResult5to8].Mathematics as Mathematics1,[StudentResult5to8].PhysArt as PhysArt1,[StudentResult5to8].Science as Science1,
                                    [StudentResult5to8].StudentId as StudentId1,[StudentResult5to8].StudentClass as StudentClass1,[StudentResult5to8].StudentRoll as StudentRoll1,
                                    [StudentResult5to8].StudentSec as StudentSec1,[StudentFormativeResult5to8].CreativeAesthe as CreativeAesthe1,
									[StudentFormativeResult5to8].EmpaCooperation as EmpaCooperation1,
                                    [StudentFormativeResult5to8].InterApplication as InterApplication1,[StudentFormativeResult5to8].StudentUnit as StudentUnit1,
                                    [StudentFormativeResult5to8].Participation as Participation1,[StudentFormativeResult5to8].QuestionExperiment as QuestionExperiment1,
									[StudentInfo].StudentName as StudentName1                                    
									into #table2 from [StudentResult5to8] 
									left join [StudentInfo] on [StudentInfo].StudentId = [StudentResult5to8].StudentId
									left join [StudentFormativeResult5to8] on [StudentFormativeResult5to8].StudentId = [StudentInfo].StudentId
									where [StudentResult5to8].StudentClass = ";

                extractResult5to8 += classNum + " and [StudentFormativeResult5to8].StudentClass = " + classNum + " and [StudentResult5to8].StudentSec = '" + sec + "' and [StudentFormativeResult5to8].StudentSec = '" + sec + "' " + @"
									--and [StudentResult5to8].StudentSec = 'A' 
									and [StudentResult5to8].StudentUnit = 2  and [StudentFormativeResult5to8].StudentUnit = 2

									Select [StudentResult5to8].Computer AS Computer2,[StudentResult5to8].EnvHis as EnvHis2,
									[StudentResult5to8].EnvironGeo AS EnvironGeo2,[StudentResult5to8].FirstLan as FirstLan2,
                                    [StudentResult5to8].SecndLan as SecndLan2,[StudentResult5to8].ThrdLan as ThrdLan2,
                                    [StudentResult5to8].Mathematics as Mathematics2,[StudentResult5to8].PhysArt as PhysArt2,[StudentResult5to8].Science as Science2,
                                    [StudentResult5to8].StudentId as StudentId2,[StudentResult5to8].StudentClass as StudentClass2,[StudentResult5to8].StudentRoll as StudentRoll2,
                                    [StudentResult5to8].StudentSec as StudentSec2,[StudentFormativeResult5to8].CreativeAesthe as CreativeAesthe2,
									[StudentFormativeResult5to8].EmpaCooperation as EmpaCooperation2,
                                    [StudentFormativeResult5to8].InterApplication as InterApplication2,[StudentFormativeResult5to8].StudentUnit as StudentUnit2,
                                    [StudentFormativeResult5to8].Participation as Participation2,[StudentFormativeResult5to8].QuestionExperiment as QuestionExperiment2,
									[StudentInfo].StudentName as StudentName2                                    
									into #table3 from [StudentResult5to8] 
									left join [StudentInfo] on [StudentInfo].StudentId = [StudentResult5to8].StudentId
									left join [StudentFormativeResult5to8] on [StudentFormativeResult5to8].StudentId = [StudentInfo].StudentId
									where [StudentResult5to8].StudentClass = ";
                extractResult5to8 += classNum + " and [StudentFormativeResult5to8].StudentClass = " + classNum + " and [StudentResult5to8].StudentSec = '" + sec + "' and [StudentFormativeResult5to8].StudentSec = '" + sec + "' " + @"
									--and [StudentResult5to8].StudentSec = 'A' 
									and [StudentResult5to8].StudentUnit = 3  and [StudentFormativeResult5to8].StudentUnit = 3
									select 
									#table1.Computer,#table1.EnvHis,#table1.EnvironGeo,#table1.FirstLan,
                                    #table1.SecndLan,#table1.ThrdLan,
                                    #table1.Mathematics,#table1.PhysArt,#table1.Science,
                                    #table1.StudentId,#table1.StudentClass,#table1.StudentRoll,
                                    #table1.StudentSec,#table1.CreativeAesthe,#table1.EmpaCooperation,
                                    #table1.InterApplication,#table1.StudentUnit,
                                    #table1.Participation,#table1.QuestionExperiment,#table1.StudentName,																		
									#table2.Computer1,#table2.EnvHis1,
									#table2.EnvironGeo1,#table2.FirstLan1,
                                    #table2.SecndLan1,#table2.ThrdLan1,
                                    #table2.Mathematics1,#table2.PhysArt1,#table2.Science1,
                                    #table2.StudentId1,#table2.StudentClass1,#table2.StudentRoll1,
                                    #table2.StudentSec1,#table2.CreativeAesthe1,
									#table2.EmpaCooperation1,
                                    #table2.InterApplication1,#table2.StudentUnit1,
                                    #table2.Participation1,#table2.QuestionExperiment1,
									#table2.StudentName1,
									#table3.Computer2,#table3.EnvHis2,
									#table3.EnvironGeo2,#table3.FirstLan2,
                                    #table3.SecndLan2,#table3.ThrdLan2,
                                    #table3.Mathematics2,#table3.PhysArt2,#table3.Science2,
                                    #table3.StudentId2,#table3.StudentClass2,#table3.StudentRoll2,
                                    #table3.StudentSec2,#table3.CreativeAesthe2,
									#table3.EmpaCooperation2,
                                    #table3.InterApplication2,#table3.StudentUnit2,
                                    #table3.Participation2,#table3.QuestionExperiment2,
									#table3.StudentName2
									from #table1 
									left join 
									#table2 on #table1.StudentId = #table2.StudentId1
									left join 
									#table3 on #table2.StudentId1 = #table3.StudentId2
									

									drop table #table2
									drop table #table1
									drop table #table3";
            }
            else if(unit==2)
            {
                extractResult5to8 = @"Select [StudentResult5to8].Computer,[StudentResult5to8].EnvHis,[StudentResult5to8].EnvironGeo,[StudentResult5to8].FirstLan,
                                    [StudentResult5to8].SecndLan,[StudentResult5to8].ThrdLan,
                                    [StudentResult5to8].Mathematics,[StudentResult5to8].PhysArt,[StudentResult5to8].Science,
                                    [StudentResult5to8].StudentId,[StudentResult5to8].StudentClass,[StudentResult5to8].StudentRoll,
                                    [StudentResult5to8].StudentSec,[StudentFormativeResult5to8].CreativeAesthe,[StudentFormativeResult5to8].EmpaCooperation,
                                    [StudentFormativeResult5to8].InterApplication,[StudentFormativeResult5to8].StudentUnit,
                                    [StudentFormativeResult5to8].Participation,[StudentFormativeResult5to8].QuestionExperiment,[StudentInfo].StudentName                                    
									--into #table1
									  from [StudentResult5to8] 
									left join [StudentInfo] on [StudentInfo].StudentId = [StudentResult5to8].StudentId
									left join [StudentFormativeResult5to8] on [StudentFormativeResult5to8].StudentId = [StudentInfo].StudentId
									where [StudentResult5to8].StudentClass = " ;
                extractResult5to8 += classNum + @"
									--and [StudentResult5to8].StudentSec = 'A' 
									and [StudentResult5to8].StudentUnit = 2";
            }
            else if (unit == 1)
            {
                extractResult5to8 = @"Select [StudentResult5to8].Computer,[StudentResult5to8].EnvHis,[StudentResult5to8].EnvironGeo,[StudentResult5to8].FirstLan,
                                    [StudentResult5to8].SecndLan,[StudentResult5to8].ThrdLan,
                                    [StudentResult5to8].Mathematics,[StudentResult5to8].PhysArt,[StudentResult5to8].Science,
                                    [StudentResult5to8].StudentId,[StudentResult5to8].StudentClass,[StudentResult5to8].StudentRoll,
                                    [StudentResult5to8].StudentSec,[StudentFormativeResult5to8].CreativeAesthe,[StudentFormativeResult5to8].EmpaCooperation,
                                    [StudentFormativeResult5to8].InterApplication,[StudentFormativeResult5to8].StudentUnit,
                                    [StudentFormativeResult5to8].Participation,[StudentFormativeResult5to8].QuestionExperiment,[StudentInfo].StudentName                                    
									--into #table1
									  from [StudentResult5to8] 
									left join [StudentInfo] on [StudentInfo].StudentId = [StudentResult5to8].StudentId
									left join [StudentFormativeResult5to8] on [StudentFormativeResult5to8].StudentId = [StudentInfo].StudentId
									where [StudentResult5to8].StudentClass = ";
                extractResult5to8 += classNum + @"
									--and [StudentResult5to8].StudentSec = 'A' 
									and [StudentResult5to8].StudentUnit = 1";
            }

            return extractResult5to8;
            
        }

        public string ExtractQueryforExtractionFor9to10(int classNum,int unit, string sec )
        {
            string extractResult9to10 = string.Empty;

            extractResult9to10 = @"
                                    Select SR.FirstLan,SR.FirstLanPrac,SR.FirstLanTheo,SR.Geography,SR.GeographyPrac,
                                    SR.GeographyTheo,SR.History,SR.HistoryPrac,SR.HistoryTheo,SR.LifeScience,SR.LifeSciencePrac,
                                    SR.LifeScienceTheo,SR.Mathematics,SR.MathematicsPrac,SR.MathematicsTheo,SR.PhysicalScience,
                                    SR.PhysicalSciencePrac,SR.PhysicalScienceTheo,SR.SecondLan,SR.SecondLanPrac,SR.SecondLanTheo,
									SR.WorkEdu,SR.WorkEduTheo,SR.WorkEduPrac,
									SR.Computer,SR.ComputerTheo,SR.ComputerPrac,
                                    SR.StudentClass,SR.StudentId,SR.StudentRoll,SR.StudentSec,SR.StudentUnit, SI.StudentName 
									into #table1 from [StudentResultFromNine] SR
                                    left join [StudentInfo] SI
                                    on SR.StudentId = SI.StudentId 
									WHERE SR.StudentUnit = 1 and SR.StudentClass = " + classNum + " and SR.StudentSec = '" + sec + "' " + Environment.NewLine;

			extractResult9to10 += @"Select SR.FirstLan AS FirstLan1,SR.FirstLanPrac as FirstLanPrac1,SR.FirstLanTheo as FirstLanTheo1,
									SR.Geography as Geography1,SR.GeographyPrac as GeographyPrac1,
                                    SR.GeographyTheo as GeographyTheo1,SR.History as History1,SR.HistoryPrac as HistoryPrac1,
									SR.HistoryTheo as HistoryTheo1,SR.LifeScience as LifeScience1,SR.LifeSciencePrac as LifeSciencePrac1,
                                    SR.LifeScienceTheo as LifeScienceTheo1,SR.Mathematics as Mathematics1,SR.MathematicsPrac as MathematicsPrac1,
									SR.MathematicsTheo as MathematicsTheo1,SR.PhysicalScience as PhysicalScience1,
                                    SR.PhysicalSciencePrac as PhysicalSciencePrac1,SR.PhysicalScienceTheo as PhysicalScienceTheo1,
									SR.SecondLan as SecondLan1,SR.SecondLanPrac as SecondLanPrac1,SR.SecondLanTheo as SecondLanTheo1,
									SR.WorkEdu as WorkEdu1,SR.WorkEduTheo as WorkEduTheo1,SR.WorkEduPrac as WorkEduPrac1,
									SR.Computer as Computer1,SR.ComputerTheo as ComputerTheo1,SR.ComputerPrac as ComputerPrac1,
                                    SR.StudentClass as StudentClass1,SR.StudentId as StudentId1,SR.StudentRoll as StudentRoll1,
									SR.StudentSec as StudentSec1,SR.StudentUnit as StudentUnit1, SI.StudentName as StudentName1 
									into #table2 from [StudentResultFromNine] SR
                                    left join [StudentInfo] SI
                                    on SR.StudentId = SI.StudentId 
									WHERE SR.StudentUnit = 2 and SR.StudentClass = " + classNum + " and SR.StudentSec = '" + sec + "' " + Environment.NewLine;

			extractResult9to10 += @"Select SR.FirstLan AS FirstLan2,SR.FirstLanPrac as FirstLanPrac2,SR.FirstLanTheo as FirstLanTheo2,
									SR.Geography as Geography2,SR.GeographyPrac as GeographyPrac2,
                                    SR.GeographyTheo as GeographyTheo2,SR.History as History2,SR.HistoryPrac as HistoryPrac2,
									SR.HistoryTheo as HistoryTheo2,SR.LifeScience as LifeScience2,SR.LifeSciencePrac as LifeSciencePrac2,
                                    SR.LifeScienceTheo as LifeScienceTheo2,SR.Mathematics as Mathematics2,SR.MathematicsPrac as MathematicsPrac2,
									SR.MathematicsTheo as MathematicsTheo2,SR.PhysicalScience as PhysicalScience2,
                                    SR.PhysicalSciencePrac as PhysicalSciencePrac2,SR.PhysicalScienceTheo as PhysicalScienceTheo2,
									SR.SecondLan as SecondLan2,SR.SecondLanPrac as SecondLanPrac2,SR.SecondLanTheo as SecondLanTheo2,
									SR.WorkEdu as WorkEdu2,SR.WorkEduTheo as WorkEduTheo2,SR.WorkEduPrac as WorkEduPrac2,
									SR.Computer as Computer2,SR.ComputerTheo as ComputerTheo2,SR.ComputerPrac as ComputerPrac2,
                                    SR.StudentClass as StudentClass2,SR.StudentId as StudentId2,SR.StudentRoll as StudentRoll2,
									SR.StudentSec as StudentSec2,SR.StudentUnit as StudentUnit2, SI.StudentName as StudentName2 
									into #table3 from [StudentResultFromNine] SR
                                    left join [StudentInfo] SI
                                    on SR.StudentId = SI.StudentId 
									WHERE SR.StudentUnit = 3 and SR.StudentClass = " + classNum + " and SR.StudentSec = '" + sec + "' " + Environment.NewLine;

            extractResult9to10 += @"Select #table1.FirstLan,#table1.FirstLanPrac,#table1.FirstLanTheo,#table1.Geography,#table1.GeographyPrac,
                                     #table1.GeographyTheo,#table1.History,#table1.HistoryPrac,#table1.HistoryTheo,#table1.LifeScience,#table1.LifeSciencePrac,
                                    #table1.LifeScienceTheo,#table1.Mathematics,#table1.MathematicsPrac,#table1.MathematicsTheo,#table1.PhysicalScience,
                                    #table1.PhysicalSciencePrac,#table1.PhysicalScienceTheo,#table1.SecondLan,#table1.SecondLanPrac,#table1.SecondLanTheo,
									#table1.WorkEdu,#table1.WorkEduTheo,#table1.WorkEduPrac,
									#table1.Computer,#table1.ComputerTheo,#table1.ComputerPrac,
                                    #table1.StudentClass,#table1.StudentId,#table1.StudentRoll,#table1.StudentSec,#table1.StudentUnit, #table1.StudentName,
									 #table2.FirstLan1,#table2.FirstLanPrac1,#table2.FirstLanTheo1,
									#table2.Geography1,#table2.GeographyPrac1,
                                    #table2.GeographyTheo1,#table2.History1,#table2.HistoryPrac1,
									#table2.HistoryTheo1,#table2.LifeScience1,#table2.LifeSciencePrac1,
                                    #table2.LifeScienceTheo1,#table2.Mathematics1,#table2.MathematicsPrac1,
									#table2.MathematicsTheo1,#table2.PhysicalScience1,
                                    #table2.PhysicalSciencePrac1,#table2.PhysicalScienceTheo1,
									#table2.SecondLan1,#table2.SecondLanPrac1,#table2.SecondLanTheo1,
									#table2.WorkEdu1,#table2.WorkEduTheo1,#table2.WorkEduPrac1,
									#table2.Computer1,#table2.ComputerTheo1,#table2.ComputerPrac1,
                                    #table2.StudentClass1,#table2.StudentId1,#table2.StudentRoll1,
									#table2.StudentSec1,#table2.StudentUnit1, #table2.StudentName1,
									 #table3.FirstLan2,#table3.FirstLanPrac2,#table3.FirstLanTheo2,
									#table3.Geography2,#table3.GeographyPrac2,
                                    #table3.GeographyTheo2,#table3.History2,#table3.HistoryPrac2,
									#table3.HistoryTheo2,#table3.LifeScience2,#table3.LifeSciencePrac2,
                                    #table3.LifeScienceTheo2,#table3.Mathematics2,#table3.MathematicsPrac2,
									#table3.MathematicsTheo2,#table3.PhysicalScience2,
                                    #table3.PhysicalSciencePrac2,#table3.PhysicalScienceTheo2,
									#table3.SecondLan2,#table3.SecondLanPrac2,#table3.SecondLanTheo2,
									#table3.WorkEdu2,#table3.WorkEduTheo2,#table3.WorkEduPrac2,
									#table3.Computer2,#table3.ComputerTheo2,#table3.ComputerPrac2,
                                    #table3.StudentClass2,#table3.StudentId2,#table3.StudentRoll2,
									#table3.StudentSec2,#table3.StudentUnit2, #table3.StudentName2

									from #table1 
									left join #table2 on #table1.StudentId = #table2.StudentId1
									left join #table3 on #table2.StudentId1 = #table3.StudentId2

									
									drop table #table2
									drop table #table1
									drop table #table3";

            return extractResult9to10;
        }
    }
}
