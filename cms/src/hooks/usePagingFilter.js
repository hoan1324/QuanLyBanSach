import { useState } from "react";

export default function usePagingFilter(initialFilter = {}) {
  const [filter, setFilter] = useState({
    pageIndex: 1,
    pageSize: 20,
    ...initialFilter,
  });

  const setPage = (pageIndex) => {
    setFilter((prev) => ({ ...prev, pageIndex }));
  };

  const setFilters = (filters) => {
    setFilter((prev) => ({ ...prev, filters, pageIndex: 1 }));
  };
  const resetFilter = () => {
    setFilter((prev) => ({
      ...prev,
      pageIndex: 1,
      ...initialFilter,
    }));
  };
  return {
    filter, // trả về filter gốc, không dùng useMemo
    setPage,
    setFilters,
    resetFilter,
  };
}
