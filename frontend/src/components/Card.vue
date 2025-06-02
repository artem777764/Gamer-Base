<script setup lang="ts">
interface CardProps {
  imageSrc: string,
  aspect?: string,
  width?: string,
}

const props = withDefaults(defineProps<CardProps>(), {
  aspect: 'aspect-[2/3]',
  width: 'w-full'
})

const fallbackImage = '/images/default-avatar.png'

function onImageError(event: Event) {
  const target = event.target as HTMLImageElement
  target.src = fallbackImage
}
</script>

<template>
  <div :class="['overflow-hidden rounded shadow-md', aspect, width]">
    <img
      :src="props.imageSrc"
      alt="Image"
      class="w-full h-full object-cover object-center"
      @error="onImageError"
    />
  </div>
</template>