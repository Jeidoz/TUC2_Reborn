using System.Collections.Generic;
using LiteDB;

namespace DataBaseManager.Entities
{
    public class Challenge
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        [BsonRef("tests")]
        public List<Test> Examples { get; set; }
        [BsonRef("tests")]
        public List<Test> ControlTests { get; set; }   
    }
}
