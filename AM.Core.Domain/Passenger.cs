using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.Core.Domain
{
    public class Passenger
    {
        public DateTime BirthDate { get; set; }

        public String FirstName { get; set; }

        public String LastName { get; set; }

        public String EmailAddress { get; set; }

        public String TelNumber { get; set; }

        public String PassportNumber { get; set; }

        public IList<Flight> Flights { get; set; }

        public int age { get; set; }


        public override String ToString()
        {
            return "Birth Date : " + BirthDate + ";FirstName : " + FirstName + ";Last Name : " + LastName +
                ";Email Address :" + EmailAddress + ";Tel Number :" + TelNumber + ";Passport Number :" + PassportNumber+
               ";age :"+age ;
        }

        //TP1.QUESTION 11

        bool CheckProfile(String first,String last)
        {
            //if(this.FirstName==first && this.LastName == last)
            //{
            //    return true;
            //}
            //return false;
            return (this.FirstName == first && this.LastName == last);
        }

        //bool CheckProfile(String first, String last,String email)
        //{
        //    return (this.FirstName == first && this.LastName == last && this.EmailAddress==email);
        //}


        // TP1.question 11.c
        bool CheckProfile(String first, String last, String email=null)
        {
            if(email== null)  return (this.FirstName == first && this.LastName == last);
            else
            return (this.FirstName == first && this.LastName == last && this.EmailAddress == email);

            //return (this.FirstName == first && this.LastName == last && (this.EmailAddress == email|| email==null));
        }

        //TP1.QUESTION 12
        public virtual string GetPassengerType()
        {
           return "I am a passenger";
                 
        }


        //passage par reference pour modifier la valeur passé en parametre
        public void GetAge(DateTime birthDate, ref int calculatedAge){
            //    calculatedAge = (DateTime.Now.Year - birthDate.Year);
            //    if (DateTime.Now.Month < birthDate.Month) calculatedAge--;
            //    else if (DateTime.Now.Month == birthDate.Month) {
            //        if (DateTime.Now.Day < birthDate.Day) calculatedAge--;
            //    }

           if(birthDate.AddYears(calculatedAge) < DateTime.Now)
            {
                calculatedAge--;
            }
        }
       public void GetAge(Passenger aPassenger)
        {
            aPassenger.age=(DateTime.Now.Year-aPassenger.BirthDate.Year);
            if (aPassenger.BirthDate.AddYears(aPassenger.age) < DateTime.Now){
                     aPassenger.age++;
            }

        }
    }
}
