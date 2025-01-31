import dayjs from "dayjs";

export const convertDates = (data) => {
  return Object.fromEntries(
    Object.entries(data).map(([key, value]) => [
      key,
      value && typeof(value)!=="number" && !isNaN(Date.parse(value)) ? dayjs(value) : value,
    ])
  );
};
export const convertDayjsToString = (data) => {
  return Object.fromEntries(
    Object.entries(data).map(([key, value]) => [
      key,
      dayjs.isDayjs(value) ? value.format("YYYY-MM-DD") : value, // Chuyển đổi nếu là dayjs
    ])
  );
};