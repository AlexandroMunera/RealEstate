import { useEffect, useState } from "react";
import type { Property } from "../types/property";

export const useProperties = () => {
  const [properties, setProperties] = useState<Property[]>([]);

  useEffect(() => {
    const fetchData = async () => {
      try {
        const response = await fetch(
          "https://68c87c5e5d8d9f5147357e23.mockapi.io/properties"
        );

        if (!response.ok) throw new Error('Erro fetching the properties');
        
        const data = await response.json();
        setProperties(data);
      } catch {
        throw new Error("Error");
      }
    };

    fetchData();
  }, []);

  return properties;
};
