using System;

namespace laba1.@class
{
    public class BdClass
    {
        public class Main
        {
            public int Id { get; set; }
            public Master Master { get; set; }
            public Discounts Discounts { get; set; }
            public TypeJob Typejob { get; set; }
            public Malfunction Malfunction { get; set; }
            public SpareParts SpareParts { get; set; }
            public Adress Adress { get; set; }
            public string Telephone { get; set; }
            public string Customer { get; set; }
            public DateTime DateOfCompletion { get; set; }
            public DateTime? TimeOfCompletion { get; set; }
            public bool Stutus { get; set; }
        }
        public class Discounts
        {
            public int Id { get; set; }
            public string Name { get; set; }
        }
        public class Master
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Dol { get; set; }
            public Adress Adress { get; set; }
        }
        public class TypeJob
        {
            public int Id { get; set; }
            public string Name { get; set; }
        }
        public class SpareParts
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Number { get; set; }
            public string Cost { get; set; }
        }
        public class Malfunction
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public SpareParts SpaseParts { get; set; }
        }
        public class Adress
        {
            public int Id { get; set; }
            public string Name { get; set; }
        }
    }
}
