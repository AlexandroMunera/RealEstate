import type { Property } from "../types/property";
import styles from "./PropertyDetails.module.css";

export const PropertyDetails = ({ data, onBackToProperties }: { data: Property, onBackToProperties: () => void }) => {
  return (
    <>
      <a onClick={onBackToProperties}>Back to properties</a>

      <div className={styles.container}>
        <img
          src={data.imageUrl}
          alt={data.name}
          width={600}
          height={400}
          className={styles.image}
        />

        <div className={styles.info}>
          <p className={styles.title}>{data.name}</p>
          <p> 🗺️ {data.address}</p>
          <p> 👤 {data.owner.name}</p>
          <p> 🗓️ {data.year}</p>
          <p className={styles.price}> $ {data.price.toLocaleString()}</p>
        </div>
      </div>
    </>
  );
};
