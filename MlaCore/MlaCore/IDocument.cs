namespace MlaCore
{
   public interface IDocument
   {
      ILockToken LockToken { get; }
      bool Published { get; set; }
   }
}