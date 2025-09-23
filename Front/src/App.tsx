import { useState } from "react";
import "./App.css";
import { Card } from "./components/Card";
import { useProperties } from "./hooks/useProperties";
import { Filters } from "./components/Filters";
import type { Property } from "./types/property";
import { getProperty } from "./services/api";
import { PropertyDetails } from "./pages/PropertyDetails";

function App() {
  const [filters, setFilters] = useState<FormData>();
  const [propertySelected, setPropertySelected] = useState<Property>();

  const properties = useProperties(filters);

  const onSearch = (filters: FormData): void => {
      setFilters(filters);
  };

  const onClickProperty = async (id: string) => {
    const property = await getProperty(id);
    setPropertySelected(property);
  };

  return (
    <div className="mainContainer">
      <header>
        <h1>Elite Properties</h1>
        <span>Premium Real Estate Collection</span>
      </header>
      <main>
        {propertySelected ? (
          <PropertyDetails />
        ) : (
          <>
            <section>
              <Filters onSearch={onSearch} />
            </section>
            <section>
              {properties.map((property) => (
                <Card
                  key={property.id}
                  data={property}
                  onClick={onClickProperty}
                />
              ))}
            </section>
          </>
        )}
      </main>
      <footer>Premium real estate collection with the best properties</footer>
    </div>
  );
}

export default App;
