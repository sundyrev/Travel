using System.ComponentModel.DataAnnotations.Schema;

namespace Travel2.Models
{
    public class Agent
    {
        int id;
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        /// <summary>
        /// Name of agent
        /// </summary>
        string name;
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        /// <summary>
        /// surname of agent
        /// </summary>
        string surname;
        public string Surname
        {
            get { return surname; }
            set { surname = value; }
        }
    }
}
