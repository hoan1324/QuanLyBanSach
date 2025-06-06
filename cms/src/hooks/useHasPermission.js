import useAuthStore from "../store/authStore";
export default function useHasPermission(permission) {
  const { getCurrentUser } = useAuthStore();
  if (getCurrentUser()?.isAdmin) {
    return true; // Admin has all permissions
  }
  const permissions = getCurrentUser()?.userPermissions || [];
  return permissions
    .map((item) => item.toLowerCase())
    .includes(permission.toLowerCase());
}
