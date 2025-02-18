import dayjs from "dayjs";

export const convertDates = (data) => {
  return Object.fromEntries(
    Object.entries(data).map(([key, value]) => [
      key,
      (key.toLowerCase().includes("date") && value && typeof (value) !== "number" && !isNaN(Date.parse(value)))
        ? dayjs(value)
        : value,
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
export const formatDateVn = (date) => {
  return date ? new Date(date).toLocaleDateString("vi-VN") : "";
};
export const convertDate = (date) => {
  return date.format("YYYY-MM-DD")
};
export const convertDateRangeToObject = (dateStart, dateEnd) => {
  return {
    from: dateStart.format("YYYY-MM-DD"),
    to: dateEnd.format("YYYY-MM-DD")
  }
};