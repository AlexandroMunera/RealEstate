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

  const onBackToProperties = () => {
    setPropertySelected(undefined);
  };

  return (
    <div className="mainContainer">
      <header>
        <div>
          <img src="logo.svg" alt="Logo" width={60} height={50} />
        </div>
        <div>
          <h1>Elite Properties</h1>
          <span>Premium Real Estate Collection</span>
        </div>
      </header>
      <main>
        {propertySelected ? (
          <PropertyDetails
            data={propertySelected}
            onBackToProperties={onBackToProperties}
          />
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

              {properties.length === 0 && (
                <p>There are not properties to show</p>
              )}
            </section>
          </>
        )}
      </main>
      <footer>
        {" "}
        🏘️ Premium real estate collection with the best properties
      </footer>
    </div>
  );
}

export default App;
