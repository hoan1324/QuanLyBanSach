import React, { createContext } from 'react';

import jobService from "./Service/jobService";
import staffService from "./Service/staffService";

// export const ServiceContext = createContext();
const services = {
    jobService,
    staffService
};
export default services
// export const ServiceProvider = ({ children }) => {
    

//     return (
//         <ServiceContext.Provider value={services}>
//             {children}
//         </ServiceContext.Provider>
//     );
// };