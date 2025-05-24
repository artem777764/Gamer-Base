<script setup lang="ts">
defineProps<{
  imageSrc: string;
}>();
</script>

<template>
  <div class="w-full aspect-[2/3] overflow-hidden rounded">
    <img
      :src="imageSrc"
      alt="Image"
      class="w-full h-full object-cover object-center"
    />
  </div>
</template>