using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using ContractSecurityBddApiTests.AppPages;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TechTalk.SpecFlow;


namespace ContractSecurityBddApiTests.StepDefinitions
{
    public class SharedData
    {
        public string uuId;
        public string uuId2;
        public int numberofTagsBefore;
        public int numberofUniqueTagsBefore;
        public List<string> listOfTags1;
        public List<string> listOfTags2;
        public string removedTag;
    }


    [Binding]
    public class VulneribilityTagsTestsSteps : BasePage
    {
        private readonly SharedData _sharedData;
        public VulneribilityTagsTestsSteps(SharedData sharedData)
        {
            _sharedData = sharedData;
        }
        public readonly AllPages Pages = new AllPages();

        [Given(@"I randomly choose a vulnerability")]
        public void GivenIRandomlyChooseAVulnerability()
        {
            var UuId = GetARandomVulnerabilityId();
            _sharedData.uuId = UuId;
            Debug.WriteLine("UuId is " +UuId);

        }

        [When(@"I add the name of enginner assigned as a tag")]
        public void WhenIAddTheNameOfEnginnerAssignedAsATag()
        {
            TagASpecificVulneribilityByName(_sharedData.uuId);
        }

        [When(@"I record the number of tags on this vulnerability")]
        public void WhenIRecordTheNumberOfTagsOnThisVulnerability()
        {
            var numberOfTags1=GetNumberOfTagsOnAVulnerability(_sharedData.uuId);
            _sharedData.numberofTagsBefore = numberOfTags1;
            Debug.WriteLine("number of tags before is " + numberOfTags1);

        }

        [When(@"I add the assigned date as a tag")]
        public void WhenIAddTheAssignedDateAsATag()
        {
            TagASpecificVulneribilityByDate(_sharedData.uuId);
        }

        [Then(@"I verify the number tags increased by one on this vulnerability")]
        public void ThenIVerifyTheNumberTagsIncreasedByOneOnThisVulnerability()
        {
            var numberOfTags2= GetNumberOfTagsOnAVulnerability(_sharedData.uuId);
            Debug.WriteLine("number of tags after is " + numberOfTags2);
            Assert.AreEqual(numberOfTags2,_sharedData.numberofTagsBefore+1,"Houston we have a problem, # of tags not increased");
        }

        [When(@"I choose another vulnerability")]
        public void WhenIChooseAnotherVulnerability()
        {
            var UuId2 = GetARandomVulnerabilityId();
            _sharedData.uuId2 = UuId2;
            Debug.WriteLine("UuId2 is " + UuId2);
        }

        [When(@"I add the same tag to the second vulnaribility")]
        public void WhenIAddTheSameTagToTheSecondVulnaribility()
        {
            TagASpecificVulneribilityByDate(_sharedData.uuId2);
        }


        [When(@"I record the number of unique tags")]
        public void WhenIRecordTheNumberOfUniqueTags()
        {
            var numberOfUniqueTagsBefore = GetNumberOfUniqueVulnerabilitieTags();
            _sharedData.numberofUniqueTagsBefore = numberOfUniqueTagsBefore;
            Debug.WriteLine("numberOfUniqueTagsBefore is " + numberOfUniqueTagsBefore);
        }

        [Then(@"I verify the number unique tags remain same")]
        public void ThenIVerifyTheNumberUniqueTagsRemainSame()
        {
            var numberOfUniqueTagsAfter = GetNumberOfUniqueVulnerabilitieTags();
            Debug.WriteLine("numberOfUniqueTagsAfter is " + numberOfUniqueTagsAfter);
            Assert.AreEqual(numberOfUniqueTagsAfter, _sharedData.numberofUniqueTagsBefore, "Houston we have a problem, # of unique tags is increased");
        }
               

        [When(@"I wait for a while")]
        public void WhenIWaitForAWhile()
        {
            Thread.Sleep(3000);
        }

        [When(@"I get the list of tags on the vulnerability")]
        public void WhenIGetTheListOfTagsOnTheVulnerability()
        {
            var ListOfTagsBefore=GetTagsOnAVulnerability(_sharedData.uuId);
            _sharedData.listOfTags1 = ListOfTagsBefore;
        }

        [When(@"I delete the tag on zeroth index")]
        public void WhenIDeleteTheTagOnZerothIndex()
        {
            var listOfTags = _sharedData.listOfTags1;
            var tagToRemove = listOfTags[0];
            _sharedData.removedTag = tagToRemove;

            RemoveTagFromAvulneribility(_sharedData.uuId, tagToRemove);
                       

        }

        [Then(@"I verify the tag is not linked anymore")]
        public void ThenIVerifyTheTagIsNotLinkedAnymore()
        {
            var ListOfTagsAfter = GetTagsOnAVulnerability(_sharedData.uuId);
            try 
            { 
                Assert.IsFalse(ListOfTagsAfter.Contains(_sharedData.removedTag)); 
            }
            catch (Exception e)
            { 
                Debug.WriteLine(e+" It is really failing here, either it is a bug or I could not delete the tag"); 
            }
            finally
            {
                Debug.WriteLine("if not fails, we have to fail it");
                Assert.IsTrue(2==5);
            }
            
        }



    }
}
