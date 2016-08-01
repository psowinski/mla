namespace MlaCore
{
   public interface IDocument
   {
      ILockToken LockToken { get; set; }
      bool Published { get; set; }
   }
}