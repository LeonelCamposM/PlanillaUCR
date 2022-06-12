using System;

namespace Application.ContextMenu
{
    public interface IContextMenuService
    {
        bool GetShowProjectsMenu();
        string GetProjectsContext();
        void SetProjectsContext(bool show, string projectName);

        void UnsetOnChange(Action action);
        void SetOnChange(Action action);
        void NotifyStateChanged();
    }
}
