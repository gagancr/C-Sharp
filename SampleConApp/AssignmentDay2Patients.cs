using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleConApp
{

    class Patient
    {
        public int PatientId { get; set; }
        public String PatientName { get; set; }
        public string PatientGender { get; set; }
        public int PatientBill { get; set; }
    }

    class PatientManager
    {
        private Patient[] _patients=null;
        private int _size = 0;
        public  PatientManager (int size)
        {
            _size = size;
            _patients = new Patient[_size];
        }

        public void AddnewPatient(Patient p)
        {
            for (int i = 0; i < _size; i++)
            {
                if (_patients[i] == null)
                {
                    _patients[i] = new Patient { PatientId = p.PatientId, PatientGender = p.PatientGender, PatientName = p.PatientName, PatientBill = p.PatientBill };
                    return;
                }
            }
        }
        public string PatientDetails(Patient p)
        {
            return $"Patient id : {p.PatientId}\nPatient name : {p.PatientName}\nPatient Gender : {p.PatientGender}\nPatient Bill :{p.PatientBill} RS ";
        }
        public void UpdatePatient(Patient p)
        {
            for (int i = 0; i < _size; i++)
            {
                if (_patients[i] != null && _patients[i].PatientId == p.PatientId)
                {
                    _patients[i].PatientName = p.PatientName;
                    Console.WriteLine();
                    Console.WriteLine("updated successfully!!!");
                    Console.WriteLine("");
                    Console.WriteLine(PatientDetails(p));
                    return;
                }
            }
            throw new Exception("patient not found to update");
        }
        public Patient FindPatient(int id)
        {
            foreach (Patient p in _patients)
            {
                if (p != null && p.PatientId == id)
                    return p;
            }
            throw new Exception("No Account found");
        }

        public void RemovePatient(int id)
        {
            try
            {
            for (int i = 0; i < _size; i++)
            {
                if (id == _patients[i].PatientId)
                {
                    _patients[i] = null;
                }
            }

            }
            catch (Exception)
            {
                Console.WriteLine();
               
            }
            
        }

        public void CollectBill(int id)
        {
            try
            {
                for (int i = 0; i < _size; i++)
                {

                    if (id == _patients[i].PatientId)
                    {
                        Console.WriteLine(PatientDetails(_patients[i]));
                        int response = Utilities.GetNumber("enter 0 to Receive the bill Amount \nEnter 1 to add expense to bill\n enter any number to exit ");
                        if (response == 0)
                        {
                            int price = Utilities.GetNumber("enter the amount to pay");
                            _patients[i].PatientBill -= price;
                            if (_patients[i].PatientBill == 0)
                                Console.WriteLine("Total bill cleared !!! Thank you");
                            else
                                Console.WriteLine("Thank you for the payment \n The Remaining bill is " + _patients[i].PatientBill);
                            price = 0;
                        }
                        else if (response == 1)
                        {
                            int price = Utilities.GetNumber("enter the amount to add to Bill");
                            _patients[i].PatientBill += price;
                            Console.WriteLine("Bill added successfullly updated bill is "+ _patients[i].PatientBill);
                            price = 0;
                        }
                        Console.WriteLine("Thank You");
                    }

                }
            }
            catch(Exception e)
            {
                //throw new Exception("error");
                Console.WriteLine(e.Message);
            }
        }
    }

    class Reception
    {
        public static PatientManager pg = null;         

        internal static void Menu()
        {
            int size = Utilities.GetNumber("enter the size");
            pg = new PatientManager(size);
            bool proc = true;
            do
            {
            Console.WriteLine("********************************************************************************************");
            Console.WriteLine("enter 1 To Register a patient \nenter 2 to update patient details \nenter 3 to get or Add Bill\nEnter 4 to Remove Patient");
            Console.WriteLine("********************************************************************************************");
                int choice = Utilities.GetNumber("enter");
                proc = processMenu(choice);
            } while (proc);
            Console.WriteLine("Thanks for using our application");
        }

        private static bool processMenu(int choice)
        {
            switch (choice)
            {
                case 1:
                    addingPatientHelper();
                    break;
                case 2:
                    updatingPatientHelper();
                    break;
                case 3:
                    BillingHelper();
                    break;

               case 4:
                    DeletePatientHelper();
                    break;
                
                default:
                    return false;
            }
            return true;

        }

        private static void DeletePatientHelper()
        {
            int id = Utilities.GetNumber("Enter the ID of the patient to Remove");
            pg.RemovePatient(id);
            Console.WriteLine("Patient removed successfully");
            Console.WriteLine();

        }

        private static void BillingHelper()
        {
           int id= Utilities.GetNumber("Enter the ID of the patient to generate bill");
            pg.CollectBill(id);
            Utilities.Prompt("Press Enter to clear the Screen");
            Console.Clear();

        }

        private static void updatingPatientHelper()
        {
             int id = Utilities.GetNumber("Enter the ID of the patient to Update");
                string name = Utilities.Prompt("Enter the  New Name of the Patient");
            Patient pp =pg.FindPatient(id);
           pp.PatientName = name;
            
            pg.UpdatePatient(pp);
                Utilities.Prompt("Press Enter to clear the Screen");
                Console.Clear();
            

        }

        private static void addingPatientHelper()
        {
            int id = Utilities.GetNumber("enter Patient Id ");
            string name = Utilities.Prompt("enter patient name");
            string gender = Utilities.Prompt("enter patients gender");
            int bill = Utilities.GetNumber("enter the bill to be paid by patient");

            Patient p = new Patient { PatientId = id, PatientName = name, PatientBill = bill, PatientGender = gender };
            pg.AddnewPatient(p);
            Console.WriteLine("Patient registered successfully!!!");
            Console.WriteLine("");
            Utilities.Prompt("Press Enter to clear the Screen");
            Console.Clear();
        }
    }
    class AssignmentDay2Patients
    {
        static void Main(string[] args)
        {
            Reception.Menu();
        }
    }
}
