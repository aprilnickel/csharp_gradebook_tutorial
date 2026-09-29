namespace Gradebook;

public class NamedObject
{
    private string name;
    public string Name
    {
        get
        {
            return name;
        }
        set
        {
            if (!String.IsNullOrEmpty(value))
            {
                name = value;
            }
            else
            {
                throw new ArgumentException("Name cannot be empty");
            }
            
        }
    }
    
    public NamedObject()
    {
        // name is optional
    }
    
    public NamedObject(string name)
    {
        Name = name;
    }
}