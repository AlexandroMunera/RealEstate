import { useEffect, useState } from "react";
import type { Property } from "../types/property";
import { getProperties } from "../services/api";

export const useProperties = () => {
  const [properties, setProperties] = useState<Property[]>([]);

  useEffect(() => {
    const fetchData = async () => {
      const data = await getProperties();
      setProperties(data);
    };

    fetchData();
  }, []);

  return properties;
};
