export const getCurrentUser = () => {
  try {
    return JSON.parse(localStorage.getItem("user"));
  } catch {
    return null;
  }
};

export const isAuthenticated = () => {
  return !!getCurrentUser();
};
