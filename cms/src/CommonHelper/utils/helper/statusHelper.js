export const statusBadge = (status, id) => {
  const result = status.find((item) => item.id === id);
  return result ? result.name : ""; // Trả về giá trị mặc định nếu không tìm thấy
};

export const statusStyle = (status, id) => {
  const result = status.find((item) => item.id === id);
  return result ? result.color : ""; // Trả về giá trị mặc định nếu không tìm thấy
};
