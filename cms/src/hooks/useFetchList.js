import { useState, useCallback, useEffect } from "react";
import { getListDropdown } from "../CommonHelper/utils/helper/communicateApi";
const useFetchList = (service) => {
  const [data, setData] = useState([]);

  const fetchData = useCallback(async () => {
    const data = await getListDropdown(service);
    console.log("Dữ liệu trả về từ useFetchList:");
    console.log(data);
    setData(data);
  }, [service]);

  useEffect(() => {
    fetchData();
  }, [fetchData]);
  return { data, refresh: fetchData };
};
export default useFetchList;
