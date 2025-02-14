import React, { createContext } from 'react';

import jobService from "./Service/jobService";
import staffService from "./Service/staffService";
import attachmentFolder from './Service/attachmentFolder';
import attachment from "./Service/attachmentService"
// export const ServiceContext = createContext();
const services = {
    jobService,
    staffService,
    attachmentFolder,
    attachment
};
export default services
// export const ServiceProvider = ({ children }) => {
    

//     return (
//         <ServiceContext.Provider value={services}>
//             {children}
//         </ServiceContext.Provider>
//     );
// };