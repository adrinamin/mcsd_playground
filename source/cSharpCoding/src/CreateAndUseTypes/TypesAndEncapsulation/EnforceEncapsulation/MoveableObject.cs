namespace TypesAndEncapsulation.EnforceEncapsulation
{
    //There is another situation in which explicit interface implementation is necessary: when a
    // class implements two interfaces that contain duplicate method signatures but wants a different
    // implementation for both. When implicitly implementing those two interfaces, only one
    // method exists in the implementation. With explicit interface implementation, both interfaces
    // have their own implementation. 
    public class MoveableObject : ILeft, IRight
    {
        void IRight.Move()
        {
            throw new System.NotImplementedException();
        }

        void ILeft.Move()
        {
            throw new System.NotImplementedException();
        }
    }
}