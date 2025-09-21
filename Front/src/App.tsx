import "./App.css";
import { Card } from "./components/Card";
import { Filters } from "./components/Filters";
import { useProperties } from "./hooks/useProperties";

function App() {

  const properties = useProperties();

  return (
    <div className="mainContainer">
      <header>
        <h1>Elite Properties</h1>
        <span>Premium Real Estate Collection</span>
      </header>
      <main>
        <aside>
          <Filters />
        </aside>
        <section>
          {properties.map((property) => (
            <Card key={property.id} data={property} />
          ))}
        </section>
      </main>
      <footer>Premium real estate collection with the best properties</footer>
    </div>
  );
}

export default App;
