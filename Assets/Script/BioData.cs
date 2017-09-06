public enum BioType
{
    FISH, LEAF, ACCESSARY, TERRAIN
};

public class BioData
{
    private BioType _type;
    private string _nameEn;
    private string _nameJp;
    public BioData ( ) { }
    public BioData SetNameEn ( string name ) { _nameEn = name; return this; }
    public BioData SetNameJp ( string name ) { _nameJp = name; return this; }
    public BioData SetType ( BioType type ) { _type = type; return this; }
}
