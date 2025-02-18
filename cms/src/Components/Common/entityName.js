import { findByID } from "../../CommonHelper/utils/helper/communicateApi"
import { useState,useCallback } from "react";
import React from "react";

function EntityName({ nameProp, id,service }) {
    const [name, setName] = useState("");
    const fetchData = useCallback(async () => {

        const response = await findByID(service, id);

        if (response != null) {
            setName(response[`${nameProp}`])
        }


    }, [id]);

    fetchData()


    return <>{name}</>;
};
export default React.memo(EntityName)