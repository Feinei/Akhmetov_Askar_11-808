    using System;
    using System.Text;

    namespace hashes
    {
	    public class GhostsTask : 
		    IFactory<Document>, IFactory<Vector>, IFactory<Segment>, IFactory<Cat>, IFactory<Robot>, 
		    IMagic
	    {
            Vector vector = new Vector(0, 0);
            Segment segment;

            private byte[] docContent = { 0, 0, 0 };
            Document document;

            Cat cat = new Cat("Cat", "Breed", DateTime.Now);

            Robot robot = new Robot("01", 100);

            public GhostsTask()
            {
                segment = new Segment(vector, vector);
                document = new Document("Doc", Encoding.ASCII, docContent);
            }

		    public void DoMagic()
		    {
                vector.Add(new Vector(1, 1));
                docContent[0] = 100;
                cat.Rename("NotCat");
                Robot.BatteryCapacity++;
		    }

		    Vector IFactory<Vector>.Create()
		    {
                return vector;
		    }

		    Segment IFactory<Segment>.Create()
		    {
                return segment;
		    }

            Document IFactory<Document>.Create()
            {
                return document;
            }

            Cat IFactory<Cat>.Create()
            {
                return cat;
            }

            Robot IFactory<Robot>.Create()
            {
                return robot;
            }
        }
    }