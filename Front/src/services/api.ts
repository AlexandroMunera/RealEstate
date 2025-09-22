const BASE_URL = "http://localhost:5125";

export const getProperties = async () => {
  try {
    const response = await fetch(`${BASE_URL}/properties`);

    if (!response.ok) throw new Error("Error fetching the properties");

    return await response.json();
  } catch {
    throw new Error("Error");
  }
};
