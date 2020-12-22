using System;

namespace Travel2.Models
{
    public class Agent
    {
        Int32 id;
        public Int32 Id
        {
            get { return id; }
            set { id = value; }
        }

        /// <summary>
        /// Name of agent
        /// </summary>
        String name;
        public String Name
        {
            get { return name; }
            set { name = value; }
        }

        /// <summary>
        /// surname of agent
        /// </summary>
        String surname;
        public String Surname
        {
            get { return surname; }
            set { surname = value; }
        }
    }
}
