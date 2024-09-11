namespace Scripts.Workflow
{
    public interface IWork
    {
        public void RunWork(float elepsedTime);
        public void ResettingWorkProgress();
        public void ActivateBackgrounImage();
        public void DeactivateBackgrounImage();
    }
}
