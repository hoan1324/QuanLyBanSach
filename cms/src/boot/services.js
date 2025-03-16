import jobService from "./Service/jobService";
import staffService from "./Service/staffService";
import attachmentFolder from './Service/attachmentFolder';
import attachment from "./Service/attachmentService"
import permissionService from './Service/permissionService';
import roleService from './Service/roleService';
import userService from './Service/userService';
import authService from './Service/authService';
// export const ServiceContext = createContext();
const services = {
    jobService,
    staffService,
    attachmentFolder,
    attachment,
    permissionService,
    roleService,
    userService,
    authService
};
export default services
// export const ServiceProvider = ({ children }) => {
    

//     return (
//         <ServiceContext.Provider value={services}>
//             {children}
//         </ServiceContext.Provider>
//     );
// };