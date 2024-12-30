import React, { createContext } from 'react';

import jobService from "./Service/jobService";


export const ServiceContext = createContext();

export const ServiceProvider = ({ children }) => {
    const services = {
        jobService
    };

    return (
        <ServiceContext.Provider value={services}>
            {children}
        </ServiceContext.Provider>
    );
};