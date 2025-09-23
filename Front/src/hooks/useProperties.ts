import { useEffect, useState } from "react";
import type { Property } from "../types/property";
import { getProperties } from "../services/api";

export const useProperties = (filters?: FormData) => {
  const [properties, setProperties] = useState<Property[]>([]);

  useEffect(() => {
    const fetchData = async () => {
      const data = await getProperties(filters);
      setProperties(data);
    };

    fetchData();
  }, [filters]);

  return properties;
};
