import { ErrorBoundary } from "react-error-boundary";
import styles from "./Filters.module.css";

export const Filters = ({onSearch}: {onSearch: (formData: FormData) => void}) => {

  return (
    <ErrorBoundary fallback="An error ocurred while searching.">
      <form action={onSearch} className={styles.container}>
        <div className={styles.filterGroup}>
          <label htmlFor="name">Name:</label>
          <input type="text" name="name" />
        </div>
        <div className={styles.filterGroup}>
          <label htmlFor="address">Address:</label>
          <input type="text" name="address" />
        </div>
        <div className={styles.filterGroup}>
          <label htmlFor="minPrice">Min Price:</label>
          <input type="number" name="minPrice" />
        </div>
        <div className={styles.filterGroup}>
          <label htmlFor="maxPrice">Max Price:</label>
          <input type="number" name="maxPrice" />
        </div>

        <button className={styles.filterButton}>Search</button>
        <a onClick={() => onSearch(new FormData())}>Clear</a>
      </form>
    </ErrorBoundary>
  );
};
