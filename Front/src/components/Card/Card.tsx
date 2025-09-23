import type { Property } from "../../types/property";
import styles from "./Card.module.css";

export const Card = ({data, onClick}: {data: Property, onClick: (id: string) => void }) => {
  return (
    <article className={styles.card} onClick={() => onClick(data.id)}>
      <img
        src={data.imageUrl}
        alt={data.name}
        width={300}
        height={200}
      />

      <div className={styles.cardContent}>
        <h4>{data.name}</h4>
        <p>Owner: {data.owner.name}</p>
        <p>Location: {data.address}</p>
      </div>

      <div className={styles.cardFooter}>
        <span>${data.price.toLocaleString()}</span>
        <span>{data.year}</span>
      </div>
    </article>
  );
};
