namespace ServerExample.Models
{
    public class PersonExersice: DbData
    {
        string personId;
        string exersiceId;
        int progress;

        public string PersonId { get=>personId; }
        public string ExersiceId {get=> exersiceId; }
        public int Progress {  get=>progress; }

        public PersonExersice(string personId, string exersiceId)
        {
            this.personId = personId;
            this.exersiceId = exersiceId;
            this.progress = 0;
        }

        public void AddProgress()
        {
            progress++;
        }
    }

}
