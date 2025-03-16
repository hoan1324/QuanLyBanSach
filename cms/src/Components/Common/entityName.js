import { useState, useCallback, useEffect } from "react";
import React from "react";
import { findByID } from "../../CommonHelper/utils/helper/communicateApi";

function EntityName({ nameProp, id, service }) {
    const [name, setName] = useState("");

    const fetchData = useCallback(async () => {
        const response = await findByID(service, id);
        if (response != null) {
            setName(response[`${nameProp}`]);
        }
    }, [id, nameProp, service]);

    useEffect(() => {
        fetchData();
    }, [fetchData]);

    return <>{name}</>;
};

export default React.memo(EntityName);
