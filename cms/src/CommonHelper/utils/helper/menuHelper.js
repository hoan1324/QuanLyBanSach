function filterMenuByPermission(menu, isAdmin = false, permissions = []) {
  if (isAdmin) {
    return menu;
  }

  return menu.map((item) => {
    if (item.children && item.children.length > 0) {
      // Lọc children theo permission
      const filteredChildren = item.children.filter((child) => {
        if (!child.permission) return true;
        return permissions.some(
          (p) => p.toLowerCase() === child.permission.toLowerCase()
        );
      });
      return { ...item, children: filteredChildren };
    }
    return item;
  });
}
export { filterMenuByPermission };
