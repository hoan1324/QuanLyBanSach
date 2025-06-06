import { useState, useCallback, useEffect } from "react";
import { getList } from "../CommonHelper/utils/helper/communicateApi";
const useFetchListFilter = (service, query) => {
  console.log("useFetchListFilter ban đầu chạy");
  console.log(query);

  const [data, setData] = useState([]);
  const [total, setTotal] = useState(1);
  const fetchData = useCallback(async () => {
    console.log("Dữ liệu trả về từ useFetchListFilter:");
    console.log(query);
    const { data, total } = await getList(service, query);

    setData(data);
    setTotal(total);
  }, [service, JSON.stringify(query)]); // Sửa ở đây

  useEffect(() => {
    fetchData();
  }, [fetchData]); // Không đổi
  return { data, total, refresh: fetchData };
};
export default useFetchListFilter;
