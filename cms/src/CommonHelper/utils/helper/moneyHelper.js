export const formatMoneyVn = (money) => {
    return money?.toLocaleString("vi-VN", { style: "currency", currency: "VND" })
}