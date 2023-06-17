namespace FlyWeight;

class TreeType //FlyWeight <= Treetype is a heavy 3D model
{
    private int model_ID; //extrinsic or uniqe data (3D model ID)
    public TreeType(int model_ID)=>this.model_ID = model_ID;

    public string Draw(Tree tree)=> $"ID:{model_ID} - a Tree drawed in {tree.x},{tree.y}";
    public int GetID()=> model_ID;
}

class Tree //Context
{
    private TreeType treeType;
    public Tree(TreeType treeType)=>this.treeType = treeType;

    public float x,y;   //intrinsic or shared data
    public void Draw()=>Console.WriteLine(treeType.Draw(this));
}

class TreeFactory //Flyweight Factory
{
    private List<TreeType> treeTypes;
    public TreeFactory(TreeType[] treeTypes)=>this.treeTypes = treeTypes.ToList();

    public TreeType GetTreeType(int model_ID){ //Get or Add!!
        TreeType temp =  treeTypes.Find(x=>x.GetID() == model_ID);
        if(temp==null){
            temp = new TreeType(model_ID);
            treeTypes.Add(temp);
        }
        return temp;
    }

    public void AllTypes(){
        Console.WriteLine("All TreeTypes:");
        foreach(TreeType treeType in treeTypes) Console.WriteLine(treeType.GetID());
    }
}

class Forest //Client
{
    private List<Tree> trees; //it can be local
    public Forest(Tree[] trees)=>this.trees = trees.ToList();

    public void AddTree(TreeType type,float x,float y){
        Tree tree = new Tree(type);
        tree.x = x;
        tree.y = y;
        trees.Add(tree);
    }

    public void Draw(){
        foreach (Tree tree in trees) tree.Draw();
    }
}

class FlyWeightRunner{
    public static void Run(){
        TreeType[] treeTypes = {new TreeType(12005),new TreeType(13001)};
        TreeFactory treeFactory = new TreeFactory(treeTypes);
        //treeFactory.GetTreeType(14123);
        treeFactory.AllTypes();

        Tree[] trees = {};
        Forest forest = new Forest(trees);
        forest.AddTree(treeFactory.GetTreeType(14123),10,2);
        forest.AddTree(treeFactory.GetTreeType(12005),11,5);
        forest.AddTree(treeFactory.GetTreeType(13001),12,8);
        forest.AddTree(treeFactory.GetTreeType(13001),13,2);
        forest.AddTree(treeFactory.GetTreeType(15008),14,0);
        forest.AddTree(treeFactory.GetTreeType(12005),18,2);

        forest.Draw();
        treeFactory.AllTypes();
    }
}