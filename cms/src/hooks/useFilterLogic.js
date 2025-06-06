import { useCallback } from "react";
import {
  convertDate,
  convertDateRangeToObject,
} from "../CommonHelper/utils/helper/dateHelper";

import constantType from "../CommonHelper/Constant/constantType";

const useFilterLogic = (filters) => {
  const assignValue = useCallback(
    (values) => {
      return filters
        .map((element) => {
          const key = element.filterFields.join(",");
          const value = values[key];

          if (
            value === undefined ||
            value === null ||
            (typeof value === "string" && value.trim().length === 0)
          )
            return null;

          if (element.filterType === constantType.filterType.dateTimePicker) {
            values[key] = convertDate(value);
          }

          if (element.filterType === constantType.filterType.rangeDatePicker) {
            values[key] = convertDateRangeToObject(value[0], value[1]);
          }

          return {
            filterFields: element.filterFields,
            value: values[key],
            condition: element.condition,
            filterType: element.filterType,
          };
        })
        .filter((item) => item !== null);
    },
    [filters]
  );

  const hasValue = useCallback((values) => {
    return Object.values(values).some((val) => val !== undefined && val !== "");
  }, []);

  return { assignValue, hasValue };
};
export default useFilterLogic;
