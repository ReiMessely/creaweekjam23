using UnityEngine;


public enum Surface //the different walking surface types
{
    //add new sounds at the bottom
    Grass,
    Tile
    
        
}
public class SoundSurfaceIDIdentifier : MonoBehaviour
{
    
    [SerializeField] private Surface _surface; //allows you to choose a surface type

    public Surface Surface
    {
        get { return _surface; }
        set { _surface = value; }
    }


}