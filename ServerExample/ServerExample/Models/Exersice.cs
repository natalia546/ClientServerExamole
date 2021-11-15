using System.Collections.Generic;

namespace ServerExample.Models
{
    public class Exersice:DbData
    {
        string title;
        public string Tiile { get => title; }
        public int StrepsCount { get => Steps.Count; }
        public List<Step> Steps;

        public Exersice(string title)
        {
            this.title = title;
            Steps = new List<Step>();
        }

        public void EditTitle(string edittitle)
        {
            title = edittitle;
        }

        public void AddStep(string description)
        {
            Steps.Add(new Step(description));
        }
        
    }

}
