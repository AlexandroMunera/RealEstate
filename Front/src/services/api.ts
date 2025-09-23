const BASE_URL = "http://localhost:5125";

export const getProperties = async (filters?: FormData) => {
  try {
    let URL = `${BASE_URL}/properties`;
    if (filters) {
      const queryParams = new URLSearchParams();
      filters.forEach((value, key) => {
        if (value) {
          queryParams.append(key, value.toString());
        }
      });
      URL += `?${queryParams.toString()}`;
    }

    const response = await fetch(URL);

    if (!response.ok) throw new Error("Error fetching the properties");

    return await response.json();
  } catch (error) {
    throw new Error(`Error: ${error}`);
  }
};

export const getProperty = async (id: string) => {
  try {
    const response = await fetch(`${BASE_URL}/properties/${id}`);

    if (!response.ok) throw new Error(`Error fetching the property with id ${id}`);

    return await response.json();
    
  } catch (error) {
    throw new Error(`Error: ${error}`);
    
  }
}
