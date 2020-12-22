using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Travel2.Models;

namespace Travel2
{
    public class Agency
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id
        {
            get; set;
        }

        /// <summary>
        /// Name of agency
        /// </summary>
        String name;
        public String Name
        {
            get { return name; }
            set { name = value; }
        }

        /// <summary>
        /// Address of agency
        /// </summary>
        String address;
        public String Address
        {
            get { return address; }
            set { address = value; }
        }

        /// <summary>
        /// Agent which cooperate with the agency
        /// </summary>
        public List<Agent> Agents
        {
            get; set;
        }
    }
}
