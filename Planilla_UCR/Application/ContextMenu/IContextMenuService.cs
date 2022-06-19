using System;

namespace Application.ContextMenu
{
    public interface IContextMenuService
    {
        bool GetShowProjectsMenu();
        string GetProjectsContext();
        void SetProjectsContext(bool showProjectMenu,bool showProjectSubMenu, string projectName, string employerEmail);
        void SetOnChange(Action action);
        void NotifyStateChanged();
        bool GetShowProjectsSubMenu();
        string GetEmployerEmailContext();
    }
}
